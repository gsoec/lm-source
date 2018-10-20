.class final Lcom/igg/sdk/account/IGGAccountSession$2;
.super Ljava/lang/Object;
.source "IGGAccountSession.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountSession;->checkGuestIsBound(Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation


# instance fields
.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;

.field final synthetic val$type:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

.field final synthetic val$typeName:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 394
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$type:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$typeName:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .locals 5
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;)V"
        }
    .end annotation

    .prologue
    .local p2, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    const/4 v4, 0x0

    const/4 v3, 0x0

    .line 397
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 398
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;

    const-string v1, ""

    invoke-interface {v0, p1, v1, v3}, Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;->onCheckGuestIsBound(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Z)V

    .line 431
    :goto_0
    return-void

    .line 402
    :cond_0
    const-string v0, "login"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    const-string v1, "1"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 403
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;

    new-instance v1, Lcom/igg/sdk/error/IGGError;

    sget-object v2, Lcom/igg/sdk/error/IGGError$Type;->BUSINESS:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v1, v2, v4}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;)V

    const-string v2, ""

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;->onCheckGuestIsBound(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Z)V

    goto :goto_0

    .line 409
    :cond_1
    const-string v0, "IggId"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_3

    const-string v0, "IggId"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v1}, Lcom/igg/sdk/account/IGGAccountSession;->getIGGId()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_3

    .line 410
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$type:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    sget-object v1, Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;->ALL_TYPE:Lcom/igg/sdk/IGGSDKConstant$ThirdAccountType;

    if-eq v0, v1, :cond_2

    .line 422
    iget-object v1, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$typeName:Ljava/lang/String;

    const-string v0, "hasbind"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    const-string v3, "1"

    invoke-virtual {v0, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    invoke-interface {v1, p1, v2, v0}, Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;->onCheckGuestIsBound(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Z)V

    goto :goto_0

    .line 425
    :cond_2
    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;

    const-string v0, "bindtype"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    const-string v1, "hasbind"

    invoke-interface {p2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    const-string v3, "1"

    invoke-virtual {v1, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    invoke-interface {v2, p1, v0, v1}, Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;->onCheckGuestIsBound(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Z)V

    goto :goto_0

    .line 429
    :cond_3
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$2;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;

    new-instance v1, Lcom/igg/sdk/error/IGGError;

    sget-object v2, Lcom/igg/sdk/error/IGGError$Type;->BUSINESS:Lcom/igg/sdk/error/IGGError$Type;

    invoke-direct {v1, v2, v4}, Lcom/igg/sdk/error/IGGError;-><init>(Lcom/igg/sdk/error/IGGError$Type;Ljava/lang/Exception;)V

    const-string v2, ""

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountSession$checkGuestIsBoundListener;->onCheckGuestIsBound(Lcom/igg/sdk/error/IGGError;Ljava/lang/String;Z)V

    goto :goto_0
.end method
