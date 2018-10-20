.class Lcom/igg/iggsdkbusiness/InputActivity$6;
.super Ljava/lang/Object;
.source "InputActivity.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/InputActivity;->SetSoftKeyborad(ZLandroid/view/View;J)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/InputActivity;

.field final synthetic val$view:Landroid/view/View;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/InputActivity;Landroid/view/View;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/InputActivity;

    .prologue
    .line 333
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/InputActivity$6;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iput-object p2, p0, Lcom/igg/iggsdkbusiness/InputActivity$6;->val$view:Landroid/view/View;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 14

    .prologue
    const/4 v4, 0x0

    .line 336
    iget-object v8, p0, Lcom/igg/iggsdkbusiness/InputActivity$6;->val$view:Landroid/view/View;

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v0

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v2

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/InputActivity$6;->val$view:Landroid/view/View;

    invoke-virtual {v5}, Landroid/view/View;->getWidth()I

    move-result v5

    int-to-float v5, v5

    iget-object v6, p0, Lcom/igg/iggsdkbusiness/InputActivity$6;->val$view:Landroid/view/View;

    invoke-virtual {v6}, Landroid/view/View;->getHeight()I

    move-result v6

    int-to-float v6, v6

    move v7, v4

    invoke-static/range {v0 .. v7}, Landroid/view/MotionEvent;->obtain(JJIFFI)Landroid/view/MotionEvent;

    move-result-object v0

    invoke-virtual {v8, v0}, Landroid/view/View;->dispatchTouchEvent(Landroid/view/MotionEvent;)Z

    .line 337
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$6;->val$view:Landroid/view/View;

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v6

    invoke-static {}, Landroid/os/SystemClock;->uptimeMillis()J

    move-result-wide v8

    const/4 v10, 0x1

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/InputActivity$6;->val$view:Landroid/view/View;

    invoke-virtual {v1}, Landroid/view/View;->getWidth()I

    move-result v1

    int-to-float v11, v1

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/InputActivity$6;->val$view:Landroid/view/View;

    invoke-virtual {v1}, Landroid/view/View;->getHeight()I

    move-result v1

    int-to-float v12, v1

    move v13, v4

    invoke-static/range {v6 .. v13}, Landroid/view/MotionEvent;->obtain(JJIFFI)Landroid/view/MotionEvent;

    move-result-object v1

    invoke-virtual {v0, v1}, Landroid/view/View;->dispatchTouchEvent(Landroid/view/MotionEvent;)Z

    .line 338
    return-void
.end method
