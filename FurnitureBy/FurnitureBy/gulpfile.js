///<binding/>
"use strict";

var gulp = require("gulp"),
    sass = require("gulp-sass"),
    concat = require('gulp-concat');

var paths = {
    webroot: "./wwwroot/"
};

gulp.task("styles", function () {
    return gulp.src(['./node_modules/bootstrap-select/dist/css/bootstrap-select.css',

                     './Styles/site.scss'])
        .pipe(sass())
        .pipe(concat('site.css'))
        .pipe(gulp.dest(paths.webroot + '/css'));
});

gulp.task('copyfonts', function () {
    return gulp.src('Fonts/*')
        .pipe(gulp.dest(paths.webroot + '/fonts'));
});

gulp.task('scripts', function () {
    return gulp.src(['./node_modules/bootstrap-select/dist/js/bootstrap-select.min.js',
                     './node_modules/bootstrap-select/dist/js/i18n/defaults-ru_RU.min.js',

                     './Scripts/site.js'
    ])
        .pipe(concat('scripts.js'))
        .pipe(gulp.dest(paths.webroot + '/js'))
});