function increment(selector) {
    let containter = $(selector);
    let fragment = document.createDocumentFragment();
    let textArea = $('<textarea>') ;
    let increamentButton = $('<button>Increment</button>');
    let addButton = $('<button>Add</button>');
    let ul = $('<ul>');

    textArea.val(0);
    textArea.addClass('counter');
    textArea.attr('disabled', true);

    increamentButton.addClass('btn').attr('id', 'incrementBtn').text("Increment");

    addButton.addClass('btn').attr('id', 'addBtn').text("Add");
    
    ul.addClass('results');


    $(increamentButton).on("click", function (){
        textArea.val(+textArea.val()+1);
    });

    $(addButton).on("click", function (){
        let li = $(`<li>${textArea.val()}</li>`);
        li.appendTo('ul');
    });

    textArea.appendTo(fragment);
    increamentButton.appendTo(fragment);
    addButton.appendTo(fragment);
    ul.appendTo(fragment);

    containter.append(fragment);
}
