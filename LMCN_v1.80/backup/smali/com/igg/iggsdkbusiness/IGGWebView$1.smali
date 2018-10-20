.class Lcom/igg/iggsdkbusiness/IGGWebView$1;
.super Ljava/lang/Object;
.source "IGGWebView.java"

# interfaces
.implements Landroid/view/View$OnTouchListener;


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

.field final synthetic val$Icon:I

.field final synthetic val$IconPress:I


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGWebView;II)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGWebView;

    .prologue
    .line 79
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGWebView$1;->this$0:Lcom/igg/iggsdkbusiness/IGGWebView;

    iput p2, p0, Lcom/igg/iggsdkbusiness/IGGWebView$1;->val$IconPress:I

    iput p3, p0, Lcom/igg/iggsdkbusiness/IGGWebView$1;->val$Icon:I

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onTouch(Landroid/view/View;Landroid/view/MotionEvent;)Z
    .locals 2
    .param p1, "v"    # Landroid/view/View;
    .param p2, "event"    # Landroid/view/MotionEvent;

    .prologue
    .line 82
    invoke-virtual {p2}, Landroid/view/MotionEvent;->getAction()I

    move-result v0

    if-nez v0, :cond_1

    .line 85
    check-cast p1, Landroid/widget/Button;

    .end local p1    # "v":Landroid/view/View;
    iget v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView$1;->val$IconPress:I

    invoke-virtual {p1, v0}, Landroid/widget/Button;->setBackgroundResource(I)V

    .line 91
    :cond_0
    :goto_0
    const/4 v0, 0x0

    return v0

    .line 86
    .restart local p1    # "v":Landroid/view/View;
    :cond_1
    invoke-virtual {p2}, Landroid/view/MotionEvent;->getAction()I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 89
    check-cast p1, Landroid/widget/Button;

    .end local p1    # "v":Landroid/view/View;
    iget v0, p0, Lcom/igg/iggsdkbusiness/IGGWebView$1;->val$Icon:I

    invoke-virtual {p1, v0}, Landroid/widget/Button;->setBackgroundResource(I)V

    goto :goto_0
.end method
