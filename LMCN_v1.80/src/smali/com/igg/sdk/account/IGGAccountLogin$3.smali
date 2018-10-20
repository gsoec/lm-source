.class Lcom/igg/sdk/account/IGGAccountLogin$3;
.super Ljava/lang/Object;
.source "IGGAccountLogin.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountLogin;->loginAsGuest(Lcom/igg/sdk/account/IGGGuest;Lcom/igg/sdk/account/LoginListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountLogin;

.field final synthetic val$deviceStorageContent:Lcom/igg/sdk/IGGDeviceStorage;

.field final synthetic val$expireTime:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/LoginListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountLogin;Lcom/igg/sdk/account/LoginListener;Ljava/lang/String;Lcom/igg/sdk/IGGDeviceStorage;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountLogin;

    .prologue
    .line 301
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->this$0:Lcom/igg/sdk/account/IGGAccountLogin;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$listener:Lcom/igg/sdk/account/LoginListener;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$expireTime:Ljava/lang/String;

    iput-object p4, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$deviceStorageContent:Lcom/igg/sdk/IGGDeviceStorage;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .locals 8
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
    .line 304
    .local p2, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 305
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$listener:Lcom/igg/sdk/account/LoginListener;

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v1

    invoke-interface {v0, p1, v1}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    .line 338
    :goto_0
    return-void

    .line 309
    :cond_0
    const-string v0, "login"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    const-string v1, "1"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 310
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$listener:Lcom/igg/sdk/account/LoginListener;

    new-instance v1, Ljava/lang/Exception;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Login failed: login:"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, "login"

    invoke-interface {p2, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const v2, 0x30d45

    invoke-static {v1, v2}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0

    .line 314
    :cond_1
    const-string v0, "IggId"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    const-string v1, ""

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 315
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$listener:Lcom/igg/sdk/account/LoginListener;

    new-instance v1, Ljava/lang/Exception;

    const-string v2, "Login failed: IGGID no value"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const v2, 0x30d46

    invoke-static {v1, v2}, Lcom/igg/sdk/error/IGGError;->businessError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v1

    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0

    .line 319
    :cond_2
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GUEST:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, "IggId"

    .line 321
    invoke-interface {p2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    const-string v2, "AccessKey"

    .line 322
    invoke-interface {p2, v2}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    const-string v3, "hasbind"

    .line 323
    invoke-interface {p2, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    const-string v4, "1"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    iget-object v4, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$expireTime:Ljava/lang/String;

    const-string v5, ""

    const-string v6, ""

    .line 319
    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    move-result-object v0

    sput-object v0, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    .line 329
    const-string v0, "uuid"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v7

    check-cast v7, Ljava/lang/String;

    .line 330
    .local v7, "uuid":Ljava/lang/String;
    if-eqz v7, :cond_3

    const-string v0, ""

    invoke-virtual {v7, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_3

    .line 331
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "uuid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGSDK;->setDeviceRegisterId(Ljava/lang/String;)V

    .line 332
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$deviceStorageContent:Lcom/igg/sdk/IGGDeviceStorage;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "uuid="

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/IGGDeviceStorage;->setDeviceUID(Ljava/lang/String;)V

    .line 333
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v0

    invoke-static {v0, v7}, Lcom/igg/util/UUIDUtil;->setUUID(Landroid/content/Context;Ljava/lang/String;)V

    .line 336
    :cond_3
    invoke-static {}, Lcom/igg/sdk/IGGAppProfile;->sharedInstance()Lcom/igg/sdk/IGGAppProfile;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igg/sdk/IGGAppProfile;->updateLastLoginTime()V

    .line 337
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountLogin$3;->val$listener:Lcom/igg/sdk/account/LoginListener;

    sget-object v1, Lcom/igg/sdk/account/IGGAccountSession;->currentSession:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-interface {v0, p1, v1}, Lcom/igg/sdk/account/LoginListener;->onLoginFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/account/IGGAccountSession;)V

    goto/16 :goto_0
.end method
