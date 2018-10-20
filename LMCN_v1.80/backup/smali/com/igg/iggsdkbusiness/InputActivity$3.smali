.class Lcom/igg/iggsdkbusiness/InputActivity$3;
.super Ljava/lang/Object;
.source "InputActivity.java"

# interfaces
.implements Landroid/view/View$OnKeyListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/InputActivity;->ShowAlertDialog([I)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/InputActivity;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/InputActivity;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/InputActivity;

    .prologue
    .line 262
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/InputActivity$3;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onKey(Landroid/view/View;ILandroid/view/KeyEvent;)Z
    .locals 2
    .param p1, "view"    # Landroid/view/View;
    .param p2, "keyCode"    # I
    .param p3, "event"    # Landroid/view/KeyEvent;

    .prologue
    .line 265
    const/4 v0, 0x4

    if-ne p2, v0, :cond_0

    .line 266
    invoke-virtual {p3}, Landroid/view/KeyEvent;->getAction()I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_0

    .line 267
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$3;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    if-eqz v0, :cond_0

    .line 268
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$3;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->dismiss()V

    .line 270
    :cond_0
    const/4 v0, 0x0

    return v0
.end method
