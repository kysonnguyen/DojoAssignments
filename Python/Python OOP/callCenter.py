from time import strftime

class Call(object):
    def __init__(self, uniqueID, name, phone, reason, time = strftime("%b %d %Y %H:%M:%S")):
        self.uniqueID = uniqueID
        self.caller = name
        self.phone = phone
        self.time = time
        self.reason = reason
    def display(self):
        print "Caller with ID",self.uniqueID, "named", self.caller, "called from:", self.phone, "at", self.time, "\nReason:", self.reason

class CallCenter(object):
    def __init__(self, *calls):
        self.calls = []
        for call in calls:
            self.calls.append(call)
        self.queue_size = len(self.calls)
    def add(self, uniqueID, name, phone, reason, time = strftime("%b %d %Y %H:%M:%S")):
        newCall = Call(uniqueID, name, phone, reason, time)
        self.calls.append(newCall)
        self.queue_size += 1
        return self
    def remove(self):
        self.calls.pop(0)
        self.queue_size -= 1
        return self
    def info(self):
        for call in self.calls:
            print "Name:", call.caller, "\nPhone Number:", call.phone
            print "*" * 30
        print "Queue Size:", self.queue_size
    def remove_by_phone(self, phone_input):
        for i in range(0, self.queue_size-1):
            if self.calls[i].phone == phone_input:
                self.calls.pop(i)
        self.queue_size = len(self.calls)
        return self

call1 = Call(1, "John", "111-111-1111", "complaint")
call2 = Call(2, "Mark", "111-111-1112", "wrong number")

call1.display()
call2.display()

center1 = CallCenter(call1, call2)
center1.add(3, "Helen", "111-111-1113", "support")
center1.info()
center1.remove_by_phone("111-111-1112").info()
