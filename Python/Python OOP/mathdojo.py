# Part I

class MathDojo1(object):
    def __init__(self):
        self.result = 0
    def add(self, *args):
        for arg in args:
            self.result += arg
        return self
    def subtract(self, *args):
        for arg in args:
            self.result -= arg
        return self

print MathDojo1().add(2).add(2, 5).subtract(3,2).result

# Part II

class MathDojo2(object):
    def __init__(self):
        self.result = 0
    def add(self, *args):
        for arg in args:
            if type(arg) == list:
                for i in arg:
                    self.result += i
            else:
                self.result += arg
        return self
    def subtract(self, *args):
        for arg in args:
            if type(arg) == list:
                for i in arg:
                    self.result -= i
            else:
                self.result -= arg
        return self

print MathDojo2().add([1],3,4).add([3, 5, 7, 8], [2, 4.3, 1.25]).subtract(2, [2,3], [1.1, 2.3]).result

#  Part III

class MathDojo3(object):
    def __init__(self):
        self.result = 0
    def add(self, *args):
        for arg in args:
            if type(arg) == list or type (arg) == tuple:
                for i in arg:
                    self.result += i
            else:
                self.result += arg
        return self
    def subtract(self, *args):
        for arg in args:
            if type(arg) == list or type (arg) == tuple:
                for i in arg:
                    self.result -= i
            else:
                self.result -= arg
        return self

print MathDojo3().add([1],(3,4)).add([3, 5, 7, 8], (2, 4.3, 1.25)).subtract(2, [2,3], [1.1, 2.3]).result
