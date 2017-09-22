import random

def scores_and_grades():
    print "Scores and Grades"
    for x in range(1,10):
        score = random.randint(60, 100)
        grade = ""
        if 59 < score <70:
            grade = "D"
        elif 69 < score < 80:
            grade = "C"
        elif 79 < score < 90:
            grade = "B"
        else:
            grade = "A"
        print "Score:",score,"; Your grade is", grade
    print "End of the program. Bye!"
scores_and_grades()
