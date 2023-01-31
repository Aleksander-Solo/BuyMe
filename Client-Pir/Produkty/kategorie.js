function toggleDocs(event)
{
	if (event.target && event.target.className == 'categories')
	{
		if(event.target.id == "cat-book"){
			const game = document.querySelector("#cat-game-list");
			game.style.visibility = "hidden";
			game.style.minHeight = "1px";
			game.style.opacity = "0";
			game.style.animation = "transitionback 0.9s";
			const film = document.querySelector("#cat-film-list");
			film.style.visibility = "hidden";
			film.style.minHeight = "1px";
			film.style.opacity = "0";
			film.style.animation = "transitionback 0.9s";
		}else if(event.target.id == "cat-game"){
			const book = document.querySelector("#cat-book-list");
			book.style.visibility = "hidden";
			book.style.minHeight = "1px";
			book.style.opacity = "0";
			book.style.animation = "transitionback 0.9s";
			const film = document.querySelector("#cat-film-list");
			film.style.visibility = "hidden";
			film.style.minHeight = "1px";
			film.style.opacity = "0";
			film.style.animation = "transitionback 0.9s";
		}else if(event.target.id == "cat-film"){
			const book = document.querySelector("#cat-book-list");
			book.style.visibility = "hidden";
			book.style.minHeight = "1px";
			book.style.opacity = "0";
			book.style.animation = "transitionback 0.9s";
			const game = document.querySelector("#cat-game-list");
			game.style.visibility = "hidden";
			game.style.minHeight = "1px";
			game.style.opacity = "0";
			game.style.animation = "transitionback 0.9s";
		}
		var next = event.target.nextElementSibling;
		
		if (next.style.visibility == "hidden")
		{
			next.style.visibility = "visible";
			next.style.minHeight = "300px";
			next.style.opacity = "1";
			next.style.animation = "transitionin 0.9s";
		} 
		else
		{
			next.style.visibility = "hidden";
			next.style.minHeight = "1px";
			next.style.opacity = "0";
			next.style.animation = "transitionback 0.9s";
		}
	}
}
document.addEventListener('click', toggleDocs, true);