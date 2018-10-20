.class Lcom/igg/android/wegamers/auth/AuthActivity$2$1;
.super Ljava/lang/Object;
.source "AuthActivity.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/android/wegamers/auth/AuthActivity$2;->onComplete(ILcom/igg/android/wegamers/auth/AuthInfo;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

.field private final synthetic val$authInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

.field private final synthetic val$iRet:I


# direct methods
.method constructor <init>(Lcom/igg/android/wegamers/auth/AuthActivity$2;ILcom/igg/android/wegamers/auth/AuthInfo;)V
    .locals 0

    .prologue
    .line 1
    iput-object p1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    iput p2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$iRet:I

    iput-object p3, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$authInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    .line 74
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 3

    .prologue
    .line 77
    const-string v0, "AuthActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "iRet = "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$iRet:I

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 78
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v0}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v0

    iget-object v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$authInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    invoke-static {v0, v1}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$2(Lcom/igg/android/wegamers/auth/AuthActivity;Lcom/igg/android/wegamers/auth/AuthInfo;)V

    .line 79
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v0}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v0

    iget v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$iRet:I

    invoke-static {v0, v1}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$3(Lcom/igg/android/wegamers/auth/AuthActivity;I)V

    .line 81
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v0}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v0

    const-string v1, ""

    const/4 v2, 0x0

    invoke-virtual {v0, v1, v2}, Lcom/igg/android/wegamers/auth/AuthActivity;->showWaitDlg(Ljava/lang/String;Z)V

    .line 83
    iget v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$iRet:I

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$authInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    if-eqz v0, :cond_0

    .line 84
    const-string v0, "AuthActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "iRet = "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$authInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    invoke-virtual {v2}, Lcom/igg/android/wegamers/auth/AuthInfo;->getGameId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 85
    const-string v0, "AuthActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "iRet = "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$authInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    invoke-virtual {v2}, Lcom/igg/android/wegamers/auth/AuthInfo;->getGameUserId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 86
    const-string v0, "AuthActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "iRet = "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$authInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    invoke-virtual {v2}, Lcom/igg/android/wegamers/auth/AuthInfo;->getToken()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 87
    const-string v0, "AuthActivity"

    new-instance v1, Ljava/lang/StringBuilder;

    const-string v2, "iRet = "

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$authInfo:Lcom/igg/android/wegamers/auth/AuthInfo;

    invoke-virtual {v2}, Lcom/igg/android/wegamers/auth/AuthInfo;->getUserIggId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 89
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v0}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v0

    invoke-static {v0}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$4(Lcom/igg/android/wegamers/auth/AuthActivity;)Landroid/widget/TextView;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v2}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v2

    invoke-static {v2}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$5(Lcom/igg/android/wegamers/auth/AuthActivity;)Ljava/lang/String;

    move-result-object v2

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    iget-object v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v2}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v2

    invoke-static {v2}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity;)Lcom/igg/android/wegamers/auth/AuthInfo;

    move-result-object v2

    invoke-virtual {v2}, Lcom/igg/android/wegamers/auth/AuthInfo;->getUserIggId()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 94
    :goto_0
    return-void

    .line 91
    :cond_0
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v0}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v0

    iget v1, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->val$iRet:I

    iget-object v2, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v2}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v2

    invoke-static {v2}, Lcom/igg/android/wegamers/auth/AuthActivity;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity;)Lcom/igg/android/wegamers/auth/AuthInfo;

    move-result-object v2

    invoke-static {v0, v1, v2}, Lcom/igg/android/wegamers/auth/WeGamersIMAuth;->sendAuthInfo(Landroid/content/Context;ILcom/igg/android/wegamers/auth/AuthInfo;)V

    .line 92
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthActivity$2$1;->this$1:Lcom/igg/android/wegamers/auth/AuthActivity$2;

    invoke-static {v0}, Lcom/igg/android/wegamers/auth/AuthActivity$2;->access$0(Lcom/igg/android/wegamers/auth/AuthActivity$2;)Lcom/igg/android/wegamers/auth/AuthActivity;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/android/wegamers/auth/AuthActivity;->finish()V

    goto :goto_0
.end method
