import gulp from 'gulp';
import cleanCSS from 'gulp-clean-css';
import rename from 'gulp-rename';
import filter from 'gulp-filter'
import terser from 'gulp-terser';;

/** This task copies npm libraries to wwwroot/ folder.
 *
 * IMPORTANT!
 * If you have other npm libs to use you have to copy from node_modules/
 * Becouse we dont want to push all the library code we use to the
 * repository.
 *
 * PACKAGE LIST:
 * bootstrap
 * jquery
 * jquery-validation
 * jquery-validation-unobtrusive
 */
gulp.task('libs', async function () {
    gulp.src('node_modules/bootstrap/dist/**/*')
        .pipe(gulp.dest('wwwroot/lib/bootstrap'));
    gulp.src('node_modules/jquery/dist/**/*')
        .pipe(gulp.dest('wwwroot/lib/jquery'));
    gulp.src('node_modules/jquery-validation/dist/**/*')
        .pipe(gulp.dest('wwwroot/lib/jquery-validation'));
    gulp.src('node_modules/jquery-validation-unobtrusive/dist/**/*')
        .pipe(gulp.dest('wwwroot/lib/jquery-validation-unobtrusive'));
});

/**
 * This tasks minimizes the css and js files and copies into 
 * same directory. It's runs on build time.
 */
gulp.task('min:css', async function () {
    let css_filter = filter(['**/*.css', '!**/*.min.css'], { restore: true });
    gulp.src('wwwroot/css/**/*css')
        .pipe(css_filter)
        .pipe(cleanCSS({ rebase: false }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('wwwroot/css'))
        .pipe(css_filter.restore);;
});
gulp.task('min:js', async function () {
    let js_filter = filter(['**/*.js', '!**/*.min.js'], { restore: true });
    gulp.src('wwwroot/js/**/*.js')
        .pipe(js_filter)
        .pipe(terser())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('wwwroot/js'))
        .pipe(js_filter.restore);
});
gulp.task('min', gulp.series('min:css', 'min:js'));

// The default gulp task.
gulp.task('default', gulp.series('libs', 'min'));
