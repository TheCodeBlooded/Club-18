locationData = []

def initialise() :
    for data in open("C:\Users\P110109979\data_file.txt", "r").readlines() :
        locationData.append([ data.split("-")[0], data.split("-")[1].replace("\n", "") ])

    print("==== Program Initialised ====")

def ageCheck(age) :
    if age >= 18 and age <= 30 :
        return True
    else :
        return False

def printLocations() :
    for i in range(len(locationData)) :
        print("Location: " + locationData[i][0] + " \n \t Price per night (per person): £" + locationData[i][1])

def getLocationData(location) :
    for i in locationData :
        if i[0].lower() == location.lower() :
            return i
    return False

def generateDiscount(personCount, price) :
    if personCount >= 5 and personCount <= 10 :
        return price * 0.95
    if personCount >= 11 and personCount <= 20 :
        
        return price * 0.9
    if personCount >= 21 :
        return price * 0.85
    return price

# Loads location data.
initialise()

# Prints out the data from the location data array.
printLocations()

#
#   Ensures the user is 18 years old.
#
age = -1

while age == -1 :
    try :
        age = int(raw_input("How old are you? "))
    except ValueError :
        print("You have entered an invalid age. Please try again")

    if ageCheck(age) == False :
        print("You're not old enough to book a holiday.")
        
        age = -1


#
#   Creates loop for validation.
#
while True :
    location = str(raw_input("Which location would you like to visit? "))

    data = getLocationData(location)

    #
    #   Checks if the location data could be found.
    #   False is returned if the data was not found.
    #
    if data != False :
        while True :
            personCount = -1
            
            try :
                personCount = int(raw_input("How many people will be attending? "))
            except ValueError :
                print("You have entered an invalid number. Please try again")

                continue

            if personCount == -1 :
                print("You have entered an invalid number. Please try again")

                continue

            print("The holiday is £" + data[1] + " per person.")

            print("The total cost for " + str(personCount) + " guests is £" + str((int(data[1]) * personCount)))

            print("With applied discount the total price is £" + str(generateDiscount(personCount, (int(data[1]) * personCount)))) 

            break
        break
    else :
        print("You have entered an invalid location")



