class Product(object):
    def __init__(self, price, item_name, weight, brand, cost):
        self.price = price
        self.item_name = item_name
        self.weight = weight
        self.brand = brand
        self.cost = cost
        self.status = "for sale"
    def sell(self):
        self.status = "sold"
        return self
    def tax(self, tax_rate):
        self.tax = tax_rate * self.price
        self.price = self.price + self.tax
        return self
    def product_return(self, reason):
        self.reason = reason
        if reason == "defective":
            self.status = "defective"
            self.price = 0
        elif reason == "opened":
            self.status = 'used'
            self.price = self.price * 0.8
        else:
            self.status = "for sale"
        return self
    def displayInfo(self):
        print "Price:", self.price
        print "Item Name:", self.item_name
        print "Weight:", self.weight
        print "Brand:", self.brand
        print "Cost:", self.cost
        print "Status:", self.status

product1 = Product(2099.00, "Surface Book", "2 lb", "Microsoft", 1300.00)

product1.sell().tax(0.08).displayInfo()
product1.product_return("opened").displayInfo()
