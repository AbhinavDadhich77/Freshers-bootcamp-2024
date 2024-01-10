class ConsoleDisplayController:
    __content = ''
    def setContent(self, message):
        self.__content = message
    def display(self):
        print(self.__content)
        
class StartsWithStrategy:
    __startsWith = ''
    def setStartsWith(self, key):
        self.__startsWith = key
    def invoke(self, item):
        if item[0].lower() == self.__startsWith.lower():
            return item
            
class StringListFilterController:
    def filter(self,strList):
        for message in strList:
            startsWith = StartsWithStrategy()
            startsWith.setStartsWith('a')
            Element = ConsoleDisplayController()
            if startsWith.invoke(message):
                Element.setContent(startsWith.invoke(message))
                Element.display()
 
arrayOfStrings = ['ayan','deep','aman','abhinav']
StringListFilter = StringListFilterController()
StringListFilter.filter(arrayOfStrings)
