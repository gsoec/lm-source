.class Lcom/igg/iggsdkbusiness/MainActivity$2;
.super Ljava/lang/Object;
.source "MainActivity.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


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


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/MainActivity;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/MainActivity;

    .prologue
    .line 51
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/MainActivity$2;->this$0:Lcom/igg/iggsdkbusiness/MainActivity;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 2
    .param p1, "v"    # Landroid/view/View;

    .prologue
    .line 55
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MainActivity$2;->this$0:Lcom/igg/iggsdkbusiness/MainActivity;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/MainActivity;->linearLayout:Landroid/widget/LinearLayout;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity$2;->this$0:Lcom/igg/iggsdkbusiness/MainActivity;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/MainActivity;->mWebview:Landroid/webkit/WebView;

    invoke-virtual {v0, v1}, Landroid/widget/LinearLayout;->removeView(Landroid/view/View;)V

    .line 56
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MainActivity$2;->this$0:Lcom/igg/iggsdkbusiness/MainActivity;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/MainActivity;->linearLayout:Landroid/widget/LinearLayout;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/MainActivity$2;->this$0:Lcom/igg/iggsdkbusiness/MainActivity;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/MainActivity;->bButton:Landroid/widget/Button;

    invoke-virtual {v0, v1}, Landroid/widget/LinearLayout;->removeView(Landroid/view/View;)V

    .line 57
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MainActivity$2;->this$0:Lcom/igg/iggsdkbusiness/MainActivity;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/MainActivity;->mContext:Lcom/igg/iggsdkbusiness/MainActivity;

    invoke-static {v0}, Lcom/igg/iggsdkbusiness/MainActivity;->access$000(Lcom/igg/iggsdkbusiness/MainActivity;)V

    .line 58
    return-void
.end method
