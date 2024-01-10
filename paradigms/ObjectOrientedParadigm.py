
class Predicate:
    def __init__(self, start_char):
        self.char = start_char

    def create_length_checker(self):
        def check_length(string):
            return len(string)==7
        return check_length

class DisplayResult:
    def __init__(self, array_of_results):
        self.results = array_of_results

    def display_results(self):
        for result in self.results:
            print(result)
        print("")
        
class Filter:
    def __init__(self, input_array):
        self.strings = input_array

    def filter_strings(self, strings, checking_criteria):
        return [string for string in strings if checking_criteria(string)]

def main():
    sample_input_array = ["Hello", "Sameera", "Abhinav", "Deep", "Air" , "vaibhav"]

    filter_instance = Filter(sample_input_array)
   
    predicate_instance = Predicate('S')
   
    checking_criteria = predicate_instance.create_length_checker()
   
    filtered_strings = filter_instance.filter_strings(filter_instance.strings, checking_criteria)

    display_instance = DisplayResult(filtered_strings)
    display_instance.display_results()

if __name__ == "__main__":
    main()
