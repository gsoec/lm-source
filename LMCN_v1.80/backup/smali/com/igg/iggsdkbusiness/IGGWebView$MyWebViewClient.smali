.class Lcom/igg/iggsdkbusiness/IGGWebView$MyWebViewClient;
.super Landroid/webkit/WebViewClient;
.source "IGGWebView.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/iggsdkbusiness/IGGWebView;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x2
    name = "MyWebViewClient"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGWebView;


# direct methods
.method private constructor <init>(Lcom/igg/iggsdkbusiness/IGGWebView;)V
    .locals 0

    .prologue
    .line 200
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGWebView$MyWebViewClient;->this$0:Lcom/igg/iggsdkbusiness/IGGWebView;

    invoke-direct {p0}, Landroid/webkit/WebViewClient;-><init>()V

    return-void
.end method


# virtual methods
.method public shouldOverrideUrlLoading(Landroid/webkit/WebView;Ljava/lang/String;)Z
    .locals 1
    .param p1, "view"    # Landroid/webkit/WebView;
    .param p2, "url"    # Ljava/lang/String;

    .prologue
    .line 205
    invoke-virtual {p1, p2}, Landroid/webkit/WebView;->loadUrl(Ljava/lang/String;)V

    .line 206
    const/4 v0, 0x1

    return v0
.end method
