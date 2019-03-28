function attachEvents() {
	$('li').click(function(e) 
    { 
		if(!$(this).attr('data') || $(this).attr('data')==='deselect'){
			$(this).attr('data', 'selected').css("background-color", "#DDD");
		}else{
			$(this).attr('data', 'deselect').css("background-color", "#808080");
		}
     	
	});
	
	$('#showTownsButton').on("click", displayValues)

	function displayValues(){
		
		let result = $(`[data='selected']`).toArray().map(x => x.textContent);
		
		$('#selectedTowns').text(result.join(', '))
		
	}
}