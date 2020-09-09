$(document).ready(function(){

	$("#loadPost").click(function(){
		loadPost();

	});




	$("#createButton").click(function(){
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

				}
				else
				{
					$("#createMsg").html("Error");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
		});
	});

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

});
