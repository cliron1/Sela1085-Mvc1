import { family } from './data.js'

// IIFE
(
	function () {
		function doShit(msg) {
			const h1 = document.querySelector('h1');
			h1.innerText = msg;
		}

		setTimeout(doShit, 2 * 1000, 'Shit happens! 123');


		let html = '';
		for (const person of family) {
			html += `<li>${person.name}</li>`
		}

		const div = document.querySelector('.container main div');
		div.innerHTML += `<ul>${html}</ul>`
	}
)();
