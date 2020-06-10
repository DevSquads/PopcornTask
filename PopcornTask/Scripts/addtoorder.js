var add_to_order;

(function () {
	
	add_to_order = function (id) {
		sendRequest(
			add_order_url,
			'Post',
			{
				popcornId: id
			},
			refresh_order_values,
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