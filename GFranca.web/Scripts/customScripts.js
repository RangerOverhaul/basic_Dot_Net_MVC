$(document).ready(function() {
    
    $('.openBtn').on('click',function(){
        $('.modal-body').load('context.html',function(){
            $('#myModal').modal({show:true});
        });
    });

    var counter = 2;
            
            $("#addButton").click(function () {
            
                if(counter>10){
                        alert("Only 10 textboxes allow");
                        return false;
                }   
                
                var newTextBoxDiv = $(document.createElement('div'))
                        .attr("id", 'TextBoxDiv' + counter)
                        .attr("class", "col-sm-6 mb-3 mb-sm-0");
                        
                var secondNewTextBoxDiv = $(document.createElement('div'))
                        .attr("id", 'secondTextBoxDiv' + counter)
                        .attr("class", "col-sm-6");
                
                newTextBoxDiv.after().html('<br> <input type="text" class="form-control form-control-user" name="textbox' + counter + 
                        '" id="textbox' + counter + '" value=""  placeholder="Elemento">');
                
                secondNewTextBoxDiv.after().html('<br> <input type="text" class="form-control form-control-user" name="textbox' + counter + 
                        '" id="secondtextbox' + counter + '" value=""  placeholder="Cantidad">');

                newTextBoxDiv.appendTo("#TextBoxesGroup");
                
                secondNewTextBoxDiv.appendTo("#TextBoxesGroup");
                
                counter++;
            });
            
            $("#removeButton").click(function () {
                if(counter==2){
                        alert("No more textbox to remove");
                        return false;
                }   
                
                counter--;
                
                $("#TextBoxDiv" + counter).remove();

                $("#secondTextBoxDiv" + counter).remove();
            
                });

                $("#getButtonValue").click(function () {
                
                var msg = '';
                for(i=1; i<counter; i++){
                        msg += "\n Elemento #" + i + " : " + $('#textbox' + i).val() + " Cantidad: "+ $('#secondtextbox' + i).val();

                }
                alert(msg);
            });
});