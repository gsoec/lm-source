.class Lcom/igg/iggsdkbusiness/IGGWebView$4;
.super Ljava/lang/Object;
.source "IGGWebView.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


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
    .line 147
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGWebView$4;->this$0:Lcom/igg/iggsdkbusiness/IGGWebView;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 1
    .param p1, "v"    # Landroid/view/View;

    .prologue
    .line 153
    :try_start_0
    invoke-static {}, Landroid/webkit/CookieManager;->getInstance()Landroid/webkit/CookieManager;

    move-result-object v0

    invoke-virtual {v0}, Landroid/webkit/CookieManager;->removeAllCookie()V

    .line 154
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView$4;->this$0:Lcom/igg/iggsdkbusiness/IGGWebView;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/IGGWebView;->finish()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 160
    :goto_0
    return-void

    .line 156
    :catch_0
    move-exception v0

    goto :goto_0
.end method
