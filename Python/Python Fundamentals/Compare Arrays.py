list_one = ['celery','carrots','bread','milk']
list_two = ['celery','carrots','bread','cream']
difference = 0

if len(list_one) == len(list_two):
    for i in range(0, len(list_one)):
        if list_one[i] != list_two[i]:
            difference +=1
else:
    difference += 1

if difference > 0:
    print "The lists are not the same"
else:
    print "The lists are the same"
