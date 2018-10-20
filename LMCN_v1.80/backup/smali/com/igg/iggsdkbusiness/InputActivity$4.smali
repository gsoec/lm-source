.class Lcom/igg/iggsdkbusiness/InputActivity$4;
.super Ljava/lang/Object;
.source "InputActivity.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


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
    .line 282
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/InputActivity$4;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 3
    .param p1, "arg0"    # Landroid/view/View;

    .prologue
    .line 285
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$4;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/InputActivity$4;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/InputActivity;->InputStrCallBack:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/InputActivity$4;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    invoke-virtual {v2}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v0, v1, v2}, Lcom/igg/iggsdkbusiness/InputActivity;->access$000(Lcom/igg/iggsdkbusiness/InputActivity;Ljava/lang/String;Ljava/lang/String;)V

    .line 286
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$4;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    if-eqz v0, :cond_0

    .line 287
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$4;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v0, v0, Lcom/igg/iggsdkbusiness/InputActivity;->build:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-virtual {v0}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->dismiss()V

    .line 288
    :cond_0
    return-void
.end method
