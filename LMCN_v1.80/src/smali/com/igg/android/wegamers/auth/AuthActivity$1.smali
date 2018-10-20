.class Lcom/igg/android/wegamers/auth/AuthActivity$1;
.super Ljava/lang/Object;
.source "AuthActivity.java"

# interfaces
.implements Landroid/view/View$OnClickListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/android/wegamers/auth/AuthActivity;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/android/wegamers/auth/AuthActivity;


# direct methods
.method constructor <init>(Lcom/igg/android/wegamers/auth/AuthActivity;)V
    .locals 0

    .prologue
    .line 1
    iput-object p1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    .line 106
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onClick(Landroid/view/View;)V
    .locals 4
    .param p1, "v"    # Landroid/view/View;

    .prologue
    .line 110
    invoke-virtual {p1}, Landroid/view/View;->getId()I

    move-result v0

    .line 112
    .local v0, "i":I
    sget v1, Lcom/igg/android/wegamers/auth/R$id;->btn_auth:I

    if-ne v0, v1, :cond_2

    .line 113
    iget-object v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    invoke-static {v1}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity;)Lcom/igg/android/wegamers/auth/AuthInfo;

    move-result-object v1

    if-eqz v1, :cond_0

    .line 117
    iget-object v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    iget-object v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    invoke-static {v2}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$1(Lcom/igg/android/wegamers/auth/AuthActivity;)I

    move-result v2

    iget-object v3, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    invoke-static {v3}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity;)Lcom/igg/android/wegamers/auth/AuthInfo;

    move-result-object v3

    invoke-static {v1, v2, v3}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->sendAuthInfo(Landroid/content/Context;ILcom/igg/android/wegamers/auth/AuthInfo;)V

    .line 119
    :cond_0
    iget-object v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    invoke-virtual {v1}, Lcom/igg/android/wegamers/auth/AuthActivity;->finish()V

    .line 125
    :cond_1
    :goto_0
    return-void

    .line 121
    :cond_2
    sget v1, Lcom/igg/android/wegamers/auth/R$id;->btn_cancel:I

    if-ne v0, v1, :cond_1

    .line 122
    iget-object v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    const/4 v2, -0x1

    iget-object v3, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    invoke-static {v3}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity;)Lcom/igg/android/wegamers/auth/AuthInfo;

    move-result-object v3

    invoke-static {v1, v2, v3}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->sendAuthInfo(Landroid/content/Context;ILcom/igg/android/wegamers/auth/AuthInfo;)V

    .line 123
    iget-object v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$1;->this$0:Lcom/igg/android/wegamers/auth/AuthActivity;

    invoke-virtual {v1}, Lcom/igg/android/wegamers/auth/AuthActivity;->finish()V

    goto :goto_0
.end method
