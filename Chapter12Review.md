# Chapter Review: "Turning Thoughts into Code"

In this chapter the authors tackle the challenge of clear communication in programming. They stress the importance of explaining ideas in plain English, advocating for code that reads like a natural language.

The chapter introduces a simple yet powerful process:
1. Describe code purpose in plain English.
2. Identify key terms.
3. Write code to match the description.

This approach is demonstrated with practical examples, emphasizing clarity in both small and large code blocks. The authors extend the concept to broader problem-solving contexts and introduce the recursive application of the method.

## Describing Logic Clearly
The section introduces a PHP code snippet for user authorization, emphasizing the need to describe logic in plain English. An alternative solution is presented, showcasing a simpler and more readable code structure.
 ```javascript
 $is_admin = is_admin_request();
 if ($document) {
    if (!$is_admin && ($document['username'] != $_SESSION['username'])) {
        return not_authorized();
    }
 } else {
    if (!$is_admin) {
        return not_authorized();
    }
 }
```
#### Alternate Solution

```javascript
 if (is_admin_request()) {
    // authorized
 } elseif ($document && ($document['username'] == $_SESSION['username'])) {
    // authorized
 } else {
    return not_authorized();
 }
 ```
## Knowing Your Libraries Helps
The section explores a jQuery code example for cycling through tips. By describing the logic in words and leveraging jQuery's features, the code is refined for better clarity and conciseness.

####  Original jQuery Implementation
```javascript
var show_next_tip = function () {
    var num_tips = $('.tip').size();
    var shown_tip = $('.tip:visible');
    var shown_tip_num = Number(shown_tip.attr('id').slice(4));
    // ... (rest of the code)
}; 
```
```javascript
var show_next_tip = function () {
    var cur_tip = $('.tip:visible').hide();
    var next_tip = cur_tip.next('.tip');
    if (next_tip.size() === 0) {
        next_tip = $('.tip:first');
    }
    next_tip.show();
}; 
```
The improved solution demonstrates fewer lines of code and a more human-readable approach.

## Applying This Method to Larger Problems
The section progresses to applying the described method to a larger function involving stock transactions. The challenge is to join data from three separate database tables based on a primary key 'time', skipping rows with unmatched times. The Python code provided illustrates the process, but raises concerns about readability and potential issues.

#### Original Python Implementation
```python
def PrintStockTransactions():
    stock_iter = db_read("SELECT time, ticker_symbol FROM ...")
    price_iter = ...
    num_shares_iter = ...
    
    while stock_iter and price_iter and num_shares_iter:
        # ... (rest of the code)
```

### An English Description of the Solution
The subsection introduces the concept of describing code solutions in plain English. A Python code example involving stock transactions is refined by extracting complex logic into a new function named `AdvanceToMatchingTime()`. The resulting code is more readable and encapsulates the details of aligning rows.

#### Improved Python Implementation
```python
def PrintStockTransactions():
    stock_iter = ...
    price_iter = ...
    num_shares_iter = ...
    while True:
        time = AdvanceToMatchingTime(stock_iter, price_iter, num_shares_iter)
        if time is None:
            return
        # ... (rest of the code)
```

### Applying the Method Recursively
The subsection explores applying the described method recursively to the AdvanceToMatchingTime() function. The improved description leads to a clearer and more elegant implementation. The code becomes simpler, with fewer tricky comparisons and generic variable names, enhancing readability.

```python
def AdvanceToMatchingTime(row_iter1, row_iter2, row_iter3):
    while row_iter1 and row_iter2 and row_iter3:    
        t1 = row_iter1.time
        t2 = row_iter2.time
        t3 = row_iter3.time
        # ... (rest of the code)
    return None  # no alignment could be found
```
The improved code demonstrates enhanced clarity and a reduction in specific details, making it more adaptable and understandable.

## Summary
The chapter highlights the powerful technique of describing code solutions in plain English before implementation. This approach aids in writing more natural and understandable code, facilitating the identification of subproblems. The process of articulating code solutions verbally is not only applicable to programming but extends to problem-solving in various contexts.

The chapter draws a parallel to the concept of "rubber ducking," where explaining a problem aloud helps in finding solutions. It emphasizes the idea that if a problem or design cannot be described in words, something may be missing or undefined. The act of verbalizing thoughts plays a crucial role in shaping and refining both programs and ideas.

