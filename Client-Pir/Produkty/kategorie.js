function toggleDocs(event)
{
	if (event.target && event.target.className == 'categories')
	{
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