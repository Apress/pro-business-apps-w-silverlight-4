function onSourceDownloadProgressChanged(sender, eventArgs) {
    var progress = Math.round((eventArgs.progress * 100));
    var ProgressBarTransform = sender.findName("ProgressBarTransform");
    var ProgressText = sender.findName("ProgressText");

    if (ProgressBarTransform != null)
        ProgressBarTransform.ScaleX = eventArgs.progress;

    if (ProgressText != null)
        ProgressText.Text = progress + "%";
}