//The build will inline common dependencies into this file.

//For any third party dependencies, like jQuery, place them in the lib folder.

//Configure loading modules from the lib directory,
//except for 'app' ones, which are in a sibling
//directory.
requirejs.config({

	baseUrl: typeof window === 'undefined' ? '' : (window.siteRoot) + 'Content/Scripts/',

	paths: {
		jquery: 'lib/jquery/jquery.min',
		react: 'lib/react/react',
		jsx: 'lib/react/JSXTransformer',
		bootstrap: 'lib/bootstrap/bootstrap.min',
		underscore: 'lib/underscore/underscore-min'
	},

	shim: {
		'bootstrap': {
			deps: ['jquery'],
			exports: '$.fn.modal'
		},

		'jquery': {
			exports: 'jQuery'
		}
	}
});
