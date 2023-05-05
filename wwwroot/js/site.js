window.onload = async () => {

    // response is stuff in the url on line 4
    const response = await fetch("http://localhost:5234/api/TodoItems/xml");
    // data = response (line4) converted to text, not converting to json
    const data = await response.text();

    // making new DOMParser object and storing it into variable parser
    var parser = new DOMParser();

    // using parser variable (DOMParser object), parsing from String (data is a string / XML is always text)
    // storing parsed data into xmlTaskList
    // "text/xml" is the document type, second argument needed for parseFromString
    let xmlTaskList = parser.parseFromString(data, "text/xml");

    // Finding all elements in document that have Tag name of Task
    // anything in <> is a tag, so <Task> in XML document is a tag
    // Storing everything that matches tag name of Task and storing it into a list
    let tasks = xmlTaskList.getElementsByTagName("Task");

    // for loop iterates each thing is list of tasks and outputting to console
    for (const t of tasks) {
        console.log(t.innerHTML);
    }
}