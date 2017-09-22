#part I
def draw_stars(arr):
    for i in arr:
            print "*" * i

arr = [4, 6, 1, 3, 5, 7, 25]
draw_stars(arr)

#part II
def draw_stars2(arr2):
    for i in arr2:
        if isinstance(i,int):
            print "*" * i
        if isinstance(i,str):
            print i[0].lower() * len(i)

arr2 = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
draw_stars2(arr2)
