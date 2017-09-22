import random
def coin_tosses(reps):
    h_count = 0
    t_count = 0
    print "Starting the program..."
    for i in range (0,reps):
        toss = round(random.random())
        if toss == 0:
            result = "It's a head!"
            h_count += 1
        else:
            result = "It's a tail!"
            t_count += 1
        print "Attempt #",i+1,": Throwing a coin...",result,"... Got",h_count,"head(s) so far and",t_count,"tail(s) so far"
    print "Ending the program, thank you!"

coin_tosses(5000)
