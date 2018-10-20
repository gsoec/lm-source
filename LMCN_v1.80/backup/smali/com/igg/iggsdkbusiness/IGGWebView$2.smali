.class Lcom/igg/iggsdkbusiness/IGGWebView$2;
.super Landroid/webkit/WebChromeClient;
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
    .line 115
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGWebView$2;->this$0:Lcom/igg/iggsdkbusiness/IGGWebView;

    invoke-direct {p0}, Landroid/webkit/WebChromeClient;-><init>()V

    return-void
.end method


# virtual methods
.method public onJsAlert(Landroid/webkit/WebView;Ljava/lang/String;Ljava/lang/String;Landroid/webkit/JsResult;)Z
    .locals 4
    .param p1, "view"    # Landroid/webkit/WebView;
    .param p2, "url"    # Ljava/lang/String;
    .param p3, "message"    # Ljava/lang/String;
    .param p4, "result"    # Landroid/webkit/JsResult;

    .prologue
    .line 119
    move-object v0, p4

    .line 120
    .local v0, "finalRes":Landroid/webkit/JsResult;
    new-instance v1, Landroid/app/AlertDialog$Builder;

    invoke-virtual {p1}, Landroid/webkit/WebView;->getContext()Landroid/content/Context;

    move-result-object v2

    invoke-direct {v1, v2}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    .line 121
    invoke-virtual {v1, p3}, Landroid/app/AlertDialog$Builder;->setMessage(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;

    move-result-object v1

    const v2, 0x104000a

    new-instance v3, Lcom/igg/iggsdkbusiness/IGGWebView$2$1;

    invoke-direct {v3, p0, v0}, Lcom/igg/iggsdkbusiness/IGGWebView$2$1;-><init>(Lcom/igg/iggsdkbusiness/IGGWebView$2;Landroid/webkit/JsResult;)V

    .line 122
    invoke-virtual {v1, v2, v3}, Landroid/app/AlertDialog$Builder;->setPositiveButton(ILandroid/content/DialogInterface$OnClickListener;)Landroid/app/AlertDialog$Builder;

    move-result-object v1

    const/4 v2, 0x0

    .line 130
    invoke-virtual {v1, v2}, Landroid/app/AlertDialog$Builder;->setCancelable(Z)Landroid/app/AlertDialog$Builder;

    move-result-object v1

    .line 131
    invoke-virtual {v1}, Landroid/app/AlertDialog$Builder;->create()Landroid/app/AlertDialog;

    move-result-object v1

    .line 132
    invoke-virtual {v1}, Landroid/app/AlertDialog;->show()V

    .line 133
    const/4 v1, 0x1

    return v1
.end method
