class Animal(object):
    def __init__(self, name, health = 50):
        self.name = name
        self.health = health
    def walk(self):
        self.health -= 1
        return self
    def run(self):
        self.health -= 5
        return self
    def displayHealth(self):
        print "Name: ", self.name, "\nHealth: ", self.health

animal1 = Animal("Kali")
animal1.walk().walk().walk().run().run().displayHealth()

class Dog(Animal):
    def __init__(self, name):
        super(Dog, self).__init__(name)
        self.health = 150
    def pet(self):
        self.health += 5
        return self

dog1 = Dog("Whoopie")
dog1.walk().walk().walk().run().run().pet().displayHealth()

class Dragon(Animal):
    def __init__(self, name):
        super(Dragon, self).__init__(name)
        self.health = 170
    def fly(self):
        self.health -= 10
        return self
    def displayHealth(self):
        print "Name: ", self.name, "\nHealth: ", self.health, " I am a Dragon"

dragon1 = Dragon('Mushu')
dragon1.fly().walk().run().displayHealth()
animal2 = Animal("Tweet")
# animal2.pet().fly().displayHealth()
# dog1.fly()
