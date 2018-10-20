.class Lcom/igg/iggsdkbusiness/InputActivity$5;
.super Ljava/lang/Object;
.source "InputActivity.java"

# interfaces
.implements Lcom/igg/iggsdkbusiness/MyAlertDialog$IOnFocusListenable;


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
    .line 323
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/InputActivity$5;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onFocusChangedListener(Z)V
    .locals 4
    .param p1, "hasFocus"    # Z

    .prologue
    .line 325
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/InputActivity$5;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/InputActivity$5;->this$0:Lcom/igg/iggsdkbusiness/InputActivity;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/InputActivity;->ed:Landroid/widget/EditText;

    const-wide/16 v2, 0x1f4

    invoke-virtual {v0, p1, v1, v2, v3}, Lcom/igg/iggsdkbusiness/InputActivity;->SetSoftKeyborad(ZLandroid/view/View;J)V

    .line 326
    return-void
.end method
