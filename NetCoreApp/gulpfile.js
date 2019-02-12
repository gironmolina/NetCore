﻿var gulp = require("gulp");
var gnf = require("gulp-npm-files");
var del = require("del");

gulp.task("clean", function () {
    return del(["./wwwroot/node_modules/" + "/**/*"]);
});

gulp.task("copynpm", function (done) {
    gulp.src(gnf(), { base: "./" }).pipe(gulp.dest("./wwwroot"));
    done();
});