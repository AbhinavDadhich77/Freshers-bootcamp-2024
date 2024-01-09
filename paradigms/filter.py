def filter(input_str , predicateFn):
    res = []
    for i in input_str:
        if predicateFn(i):
            res.append(i)
    return res
    
def checkStringStartAndEndsWith(start_char , end_char):
    predicate = lambda string_item: string_item[0]==start_char and string_item[-1]==end_char
    return predicate
    
def printArray(array):
    for item in array:
        print(item)
        
string = ["abhinav" , "deepanshu" , "hello" , "world" , "hero"]
result = filter(string , checkStringStartAndEndsWith("h","o"))
printArray(result)
    
