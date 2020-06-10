var delete_order_item;
var plus_order_item;
var minus_order_item;
var delete_order;

(function () {

	//$('.qty_sub').on('click', function()
	//{
	//	original = parseFloat(qty.find('.product_num').text());
	//	if(original > 0)
	//	{
	//		newValue = original - 1;
	//	}
	//	num.text(newValue);
	//});

	//$('.qty_add').on('click', function () {
	//	original = parseFloat(qty.find('.product_num').text());
	//	newValue = original + 1;
	//	num.text(newValue);
	//});

	delete_order_item = function (id) {
		sendRequest(
			delete_order_item_url,
			'Post',
			{
				orderItemId: id
			},
			function () {
				($('.cart_item.oi' + id)).slideUp(function () { ($('.cart_item.oi' + id)).remove(); });
				refresh_order_values();
			},
			function () { });
	}

	delete_order = function () {
		sendRequest(
			delete_order_url,
			'Post',
			{},
			function () {
				($('.cart_items_list')).slideUp(function () { ($('.cart_items_list')).empty(); });
				refresh_order_values();
			},
			function () { });
	}

	plus_order_item = function (id) {
		sendRequest(
			order_item_plus_url,
			'Post',
			{
				orderItemId: id
			},
			function (data) {
				set_order_item_values(id, data);
				refresh_order_values();
			},
			function () { });
	}

	minus_order_item = function (id) {
		sendRequest(
			order_item_minus_url,
			'Post',
			{
				orderItemId: id
			},
			function (data) {
				set_order_item_values(id, data);
				refresh_order_values();
			},
			function () { });
	}

	var refresh_order_values = function () {
		sendRequest(
			get_order_values_url,
			'Get',
			{},
			set_order_values_in_view,
			function () { });
	}

	var set_order_values_in_view = function (data) {
		$('.cart_price').html('$' + data.total_cost.toFixed(2));
		$('.cart_num').html(data.order_count);
	}

	var set_order_item_values = function (id, data) {
		var total_label = "<span>Total: </span>$";
		$('.item_count' + id).html(data.count);
		$('.item_total' + id).html(total_label + data.total.toFixed(2));
	}

	//type: Post/Get
	//data: object -> key & value
	function sendRequest(url, type, data, success, error) {
		$.ajax({
			url: url,
			type: 'Post',
			datatype: "json",
			data: data,
			success: success,
			error: error
		});
	}


})();