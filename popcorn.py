from flask import Flask, render_template, request ,redirect, url_for
from werkzeug.security import generate_password_hash, check_password_hash


class Item:
    owned = False
    amount = 0
    name = id = type = ""
    price = None

    def __init__(self, id, name, price, type):
        self.id = id
        self.price = price
        self.name = name
        self.type = type

    def buy(self, amount):
        if amount > 0:
            self.owned = True
            self.amount += amount

    def sell(self, amount):
        self.amount -= amount
        if self.amount < 1:
            self.owned = False
            self.amount = 0


class User:
    username = password = None
    items = {}

    # unique number of items and total number of items can be calculated  from the items dict
    def buy(self, item, amount):
        if item.owned:
            item.buy(amount)
            self.items[item.id] = item
            ## is editing the item in the obj itself edits it later on in the dict if so then the line obve isnt needed "plz chck"
        else:
            item.buy(amount)
            self.items[item.id] = item

    def sell(self, item, amount):
        if item.owned:
            item.sell(amount)
            self.items[item.id] = item
            ## this line toooo
        if not item.owned:
            del self.items[item.id]

    def set_password(self, password):
        self.password = generate_password_hash(password)

    def check_password(self, password):
        return check_password_hash(self.password, password)

    def set_username(self, username):
        self.username = username


app = Flask(__name__)
# preexisting user
u = User()
u.set_username('MyUser')
u.set_password('MyUser')



# login page
@app.route("/")
def login():
    return render_template('login.html')

@app.route('/table' , methods=['GET','POST'])
def LoadTable():
    # declaring items
    item1 = Item('1', 'caramel', 25, 'filled with caramel')
    item2 = Item('2', 'salt', 20, 'filled with salt')
    item3 = Item('3', 'pepper', 19, 'filled with pepper')
    item4 = Item('4', 'blank', 15, 'filled with popcorn')

    # filling the list
    shoppinglist = {
        'id1': item1,
        'id2': item2,
        'id3': item3,
        'id4': item4,
    }
    print(shoppinglist)
    return render_template('table.html' , shoppinglist=shoppinglist)


# handling login page
@app.route('/login', methods=['POST'])
def loginHandle():
    gvnuser = request.form['name']
    gvnpass = request.form['password']
    if gvnuser == u.username and u.check_password(gvnpass):
        return redirect('/table')
    else:
        return 'wrong username or password'


app.run(debug=True)
