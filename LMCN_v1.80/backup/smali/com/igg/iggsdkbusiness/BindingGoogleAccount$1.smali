.class Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;
.super Ljava/lang/Object;
.source "BindingGoogleAccount.java"

# interfaces
.implements Lcom/igg/sdk/account/IGGAccountBind$BindListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->bindingGoogle(Ljava/lang/String;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/BindingGoogleAccount;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    .prologue
    .line 75
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onBindFinished(ZZZ)V
    .locals 7
    .param p1, "success"    # Z
    .param p2, "hadBeenBound"    # Z
    .param p3, "isFirstAuthorize"    # Z

    .prologue
    .line 78
    const-string v4, "LinkGoogleAccount"

    const-string v5, "onBindFinished 1"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 79
    if-eqz p1, :cond_0

    .line 81
    :try_start_0
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4}, Lcom/igg/sdk/account/IGGAccountSession;->getExtra()Ljava/util/Map;

    move-result-object v3

    .line 82
    .local v3, "oldExtra":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    sget-object v4, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->BindNameTag:Ljava/lang/String;

    sget-object v5, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->lastAccount:Ljava/lang/String;

    invoke-interface {v3, v4, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 83
    sget-object v4, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v4, v3}, Lcom/igg/sdk/account/IGGAccountSession;->setExtra(Ljava/util/Map;)V

    .line 84
    const/4 v1, 0x0

    .line 85
    .local v1, "json":Lorg/json/JSONObject;
    new-instance v2, Ljava/util/HashMap;

    invoke-direct {v2}, Ljava/util/HashMap;-><init>()V

    .line 86
    .local v2, "map":Ljava/util/Map;
    const-string v4, "name"

    sget-object v5, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->lastAccount:Ljava/lang/String;

    invoke-interface {v2, v4, v5}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 87
    new-instance v1, Lorg/json/JSONObject;

    .end local v1    # "json":Lorg/json/JSONObject;
    invoke-direct {v1, v2}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    .line 88
    .restart local v1    # "json":Lorg/json/JSONObject;
    const-string v4, "BindingGoogleAccount"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "lastAccount = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    sget-object v6, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->lastAccount:Ljava/lang/String;

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 89
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->SuccessfulCallBack:Ljava/lang/String;

    invoke-virtual {v1}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 109
    .end local v1    # "json":Lorg/json/JSONObject;
    .end local v2    # "map":Ljava/util/Map;
    .end local v3    # "oldExtra":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    :goto_0
    return-void

    .line 90
    :catch_0
    move-exception v0

    .line 91
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0

    .line 96
    .end local v0    # "e":Ljava/lang/Exception;
    :cond_0
    const-string v4, "LinkGoogleAccount"

    const-string v5, "onBindFinished 2"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 97
    if-eqz p3, :cond_1

    .line 99
    const-string v4, "LinkGoogleAccount"

    const-string v5, "onBindFinished 3"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 102
    :cond_1
    if-eqz p2, :cond_2

    .line 103
    const-string v4, "LinkGoogleAccount"

    const-string v5, "onBindFinished 4"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 104
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->FailedCallBack:Ljava/lang/String;

    const-string v6, "1"

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 107
    :cond_2
    const-string v4, "LinkGoogleAccount"

    const-string v5, "onBindFinished 5"

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 108
    iget-object v4, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    iget-object v5, p0, Lcom/igg/iggsdkbusiness/BindingGoogleAccount$1;->this$0:Lcom/igg/iggsdkbusiness/BindingGoogleAccount;

    iget-object v5, v5, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->FailedCallBack:Ljava/lang/String;

    const-string v6, "2"

    invoke-virtual {v4, v5, v6}, Lcom/igg/iggsdkbusiness/BindingGoogleAccount;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
