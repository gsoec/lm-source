.class Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;
.super Ljava/lang/Object;
.source "RealNameVerificationHelper.java"

# interfaces
.implements Lcom/igg/sdk/realname/IGGVerificationStateListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->CheckRealNameState()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    .prologue
    .line 83
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onResult(Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;Lcom/igg/sdk/error/IGGError;)V
    .locals 4
    .param p1, "result"    # Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;
    .param p2, "error"    # Lcom/igg/sdk/error/IGGError;

    .prologue
    .line 86
    invoke-virtual {p2}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v1

    if-eqz v1, :cond_4

    .line 89
    invoke-virtual {p1}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->getState()Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    move-result-object v0

    .line 90
    .local v0, "state":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->TAG:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "state = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 91
    sget-object v1, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationUnauthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    if-ne v0, v1, :cond_0

    .line 92
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->RealNameCheckCallBack:Ljava/lang/String;

    const-string v3, "4"

    invoke-virtual {v1, v2, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 110
    .end local v0    # "state":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    :goto_0
    return-void

    .line 93
    .restart local v0    # "state":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    :cond_0
    sget-object v1, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationSumbitted:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    if-ne v0, v1, :cond_1

    .line 94
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->RealNameCheckCallBack:Ljava/lang/String;

    const-string v3, "1"

    invoke-virtual {v1, v2, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 95
    :cond_1
    sget-object v1, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;->IGGRealNameVerificationAuthorized:Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;

    if-ne v0, v1, :cond_3

    .line 97
    invoke-virtual {p1}, Lcom/igg/sdk/realname/bean/IGGRealNameVerificationResult;->isMinor()Z

    move-result v1

    if-eqz v1, :cond_2

    .line 98
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->RealNameCheckCallBack:Ljava/lang/String;

    const-string v3, "3"

    invoke-virtual {v1, v2, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 100
    :cond_2
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->RealNameCheckCallBack:Ljava/lang/String;

    const-string v3, "2"

    invoke-virtual {v1, v2, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 103
    :cond_3
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->RealNameCheckCallBack:Ljava/lang/String;

    const-string v3, "4"

    invoke-virtual {v1, v2, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 107
    .end local v0    # "state":Lcom/igg/sdk/realname/bean/IGGRealNameVerificationState;
    :cond_4
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->TAG:Ljava/lang/String;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "requestState error  = "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {p2}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 108
    iget-object v1, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, p0, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper$1;->this$0:Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;

    iget-object v2, v2, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->RealNameCallBackFailed:Ljava/lang/String;

    invoke-virtual {p2}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v3

    invoke-static {v3}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Lcom/igg/iggsdkbusiness/RealNameVerificationHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
