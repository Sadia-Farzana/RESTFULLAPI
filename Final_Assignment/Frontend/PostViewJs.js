
$(document).ready(function(){

var split;

ComboSelectLoadPosts();

	$("#loadPost").click(function(){
		loadPost();

	});

  	$("#editpostselect").change(function(){
  		split=	$("#editpostselect").val().split("--");
      $("#editPost").val(split[1]);
  	});
    $("#SaveButton").click(function(){
    		EditPost();
    	});
    $("#createButton").click(function(){
    		CreatePost();
    	});
      $("#deletepostselect").change(function(){
  		split=$("#deletepostselect").val().split("--");
  	});

    $("#deleteButton").click(function(){
    		deletePost();
    	});

function CreatePost() {
  $.ajax({
    url:"https://localhost:44304/api/posts",
    method:"post",
    headers:{
      contentType:"application/json"
    },
    data:{
      PostName:$("#PostName").val()
    },
    complete:function(xmlHttp,status){
      if(xmlHttp.status==201)
      {
        $("#createMsg").html("Post created");
        $("#PostName").val("");
        loadPost();
				ComboSelectLoadPosts();

      }
      else
      {
        $("#createMsg").html("Error");
        console.log(xmlHttp.status+":"+xmlHttp.statusText);
      }
    }
  });
}



function EditPost() {
  $.ajax({
    url:"https://localhost:44304/api/posts/"+split[0],
    method:"put",
    headers:{
      contentType:"application/json"
    },
    data:{
      PostName:$("#editPost").val()
    },
    complete:function(xmlHttp,status){
      if(xmlHttp.status==200)
      {
        $("#editMsg").html("Post edited");
        $("#editMsg").val("");
        loadPost();
				ComboSelectLoadPosts();

      }
      else
      {
        $("#editMsg").html("Error");
        console.log(xmlHttp.status+":"+xmlHttp.statusText);
      }
    }
  });
}
function deletePost()
{
	$.ajax({
			url:"http://localhost:44304/api/posts/"+split[0],
			method:"delete",
			headers:{
				contentType:"application/json"
			},
			complete:function(xmlHttp,status){
				if(xmlHttp.status==204)
				{
					location.reload();
					$("#deleteMsg").html("Post deleted");

					loadPost();
					ComboSelectLoadPosts();

				}
				else
				{
					$("#deleteMsg").html("Error");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
		});
}
function loadPost()
{
	$.ajax({
			url:"https://localhost:44304/api/posts",
			method:"get",
			complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{
					var data=xmlHttp.responseJSON;
					var str='';
					for (var i = 0; i < data.length; i++) {

						str+="<tr><td>"+data[i].PostId+"</td> <td>"+data[i].PostName+"</td></tr>";
						$("#PostList").html(str);
					};

				}
				else
				{
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}

		});
}


function ComboSelectLoadPosts()
{
	$.ajax({
				url:"https://localhost:44304/api/posts",
			method:"get",
			complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{
					var data=xmlHttp.responseJSON;
					var str='';
					for (var i = 0; i < data.length; i++) {
						str+="<option>"+data[i].PostId+"--"+data[i].PostName+"</option>";
						$("#editpostselect").html(str);
						$("#deletepostselect").html(str);
					};

				}
				else
				{
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}

		});
  }



});
