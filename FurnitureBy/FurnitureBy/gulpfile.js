﻿///<binding/>
"use strict";

var gulp = require("gulp"),
    sass = require("gulp-sass");

var paths = {
    webroot: "./wwwroot/"
};

gulp.task("styles", function () {
    return gulp.src('Styles/site.scss')
        .pipe(sass())
        .pipe(gulp.dest(paths.webroot + '/css'));
});