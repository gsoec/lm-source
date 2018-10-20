.class Lcom/igg/iggsdkbusiness/IGGWebView$3;
.super Landroid/webkit/WebViewClient;
.source "IGGWebView.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGWebView;->onCreate(Landroid/os/Bundle;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGWebView;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGWebView;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGWebView;

    .prologue
    .line 136
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGWebView$3;->this$0:Lcom/igg/iggsdkbusiness/IGGWebView;

    invoke-direct {p0}, Landroid/webkit/WebViewClient;-><init>()V

    return-void
.end method


# virtual methods
.method public onReceivedError(Landroid/webkit/WebView;ILjava/lang/String;Ljava/lang/String;)V
    .locals 1
    .param p1, "view"    # Landroid/webkit/WebView;
    .param p2, "errorCode"    # I
    .param p3, "description"    # Ljava/lang/String;
    .param p4, "failingUrl"    # Ljava/lang/String;

    .prologue
    .line 139
    const-string v0, "error"

    invoke-static {v0, p3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 141
    return-void
.end method
