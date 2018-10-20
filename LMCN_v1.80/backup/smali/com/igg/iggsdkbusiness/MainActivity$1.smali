.class Lcom/igg/iggsdkbusiness/MainActivity$1;
.super Landroid/webkit/WebViewClient;
.source "MainActivity.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/MainActivity;->onCreate(Landroid/os/Bundle;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/MainActivity;

.field final synthetic val$activity:Landroid/app/Activity;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/MainActivity;Landroid/app/Activity;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/MainActivity;

    .prologue
    .line 42
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/MainActivity$1;->this$0:Lcom/igg/iggsdkbusiness/MainActivity;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/MainActivity$1;->val$activity:Landroid/app/Activity;

    invoke-direct {p0}, Landroid/webkit/WebViewClient;-><init>()V

    return-void
.end method


# virtual methods
.method public onReceivedError(Landroid/webkit/WebView;ILjava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p1, "view"    # Landroid/webkit/WebView;
    .param p2, "errorCode"    # I
    .param p3, "description"    # Ljava/lang/String;
    .param p4, "failingUrl"    # Ljava/lang/String;

    .prologue
    .line 44
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MainActivity$1;->val$activity:Landroid/app/Activity;

    const/4 v1, 0x0

    invoke-static {v0, p3, v1}, Landroid/widget/Toast;->makeText(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/widget/Toast;

    move-result-object v0

    invoke-virtual {v0}, Landroid/widget/Toast;->show()V

    .line 45
    return-void
.end method
