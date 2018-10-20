.class Lcom/igg/sdk/account/IGGAccountSession$1;
.super Ljava/lang/Object;
.source "IGGAccountSession.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/account/IGGAccountSession;->verifyIfNeed(Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/account/IGGAccountSession;

.field final synthetic val$accessKey:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;

.field final synthetic val$session:Lcom/igg/sdk/account/IGGAccountSession;


# direct methods
.method constructor <init>(Lcom/igg/sdk/account/IGGAccountSession;Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;Lcom/igg/sdk/account/IGGAccountSession;Ljava/lang/String;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/account/IGGAccountSession;

    .prologue
    .line 234
    iput-object p1, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->this$0:Lcom/igg/sdk/account/IGGAccountSession;

    iput-object p2, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;

    iput-object p3, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    iput-object p4, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$accessKey:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .locals 12
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
    .line 238
    .local p2, "map":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;"
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 239
    const-string v0, "IGGLoginSession"

    const-string v1, " Because the network can not connect, accesskey could not be verified"

    invoke-static {v0, v1}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 274
    :goto_0
    return-void

    .line 243
    :cond_0
    const-string v0, "IggId"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Ljava/lang/String;

    .line 244
    .local v8, "iggid":Ljava/lang/String;
    if-eqz v8, :cond_1

    const-string v0, ""

    invoke-virtual {v8, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 246
    :cond_1
    const-string v0, "IGGLoginSession"

    const-string v1, "accesskey expirtion from local storage is Invalid"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 247
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;->GUEST:Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    const-string v1, ""

    const-string v2, ""

    const/4 v3, 0x0

    const-string v4, ""

    const-string v5, ""

    const-string v6, ""

    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    .line 248
    invoke-static {}, Lcom/igg/sdk/account/IGGAccountSession;->invalidateCurrentSession()Lcom/igg/sdk/account/IGGAccountSession;

    .line 249
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;

    const/4 v1, 0x0

    const/4 v2, 0x1

    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;->onSessionExpired(ZZLcom/igg/sdk/account/IGGAccountSession;)V

    goto :goto_0

    .line 254
    :cond_2
    const-string v0, "keep_time"

    invoke-interface {p2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-static {v0}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v10

    .line 255
    .local v10, "keepTime":J
    new-instance v7, Ljava/text/SimpleDateFormat;

    const-string v0, "yyyy-MM-dd HH:mm:ss"

    sget-object v1, Ljava/util/Locale;->US:Ljava/util/Locale;

    invoke-direct {v7, v0, v1}, Ljava/text/SimpleDateFormat;-><init>(Ljava/lang/String;Ljava/util/Locale;)V

    .line 256
    .local v7, "df":Ljava/text/SimpleDateFormat;
    new-instance v0, Ljava/util/Date;

    invoke-direct {v0}, Ljava/util/Date;-><init>()V

    invoke-virtual {v0}, Ljava/util/Date;->getTime()J

    move-result-wide v0

    const-wide/16 v2, 0x3e8

    mul-long/2addr v2, v10

    add-long/2addr v0, v2

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    invoke-virtual {v7, v0}, Ljava/text/SimpleDateFormat;->format(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v4

    .line 257
    .local v4, "timeToVerify":Ljava/lang/String;
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0, v4}, Lcom/igg/sdk/account/IGGAccountSession;->setTimeToVerify(Ljava/lang/String;)V

    .line 260
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    .line 261
    invoke-static {v0}, Lcom/igg/sdk/account/IGGAccountSession;->access$000(Lcom/igg/sdk/account/IGGAccountSession;)Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;

    move-result-object v0

    const-string v1, "IggId"

    .line 262
    invoke-interface {p2, v1}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$accessKey:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    .line 264
    invoke-static {v3}, Lcom/igg/sdk/account/IGGAccountSession;->access$100(Lcom/igg/sdk/account/IGGAccountSession;)Z

    move-result v3

    iget-object v5, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    .line 266
    invoke-static {v5}, Lcom/igg/sdk/account/IGGAccountSession;->access$200(Lcom/igg/sdk/account/IGGAccountSession;)Ljava/lang/String;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    .line 267
    invoke-static {v6}, Lcom/igg/sdk/account/IGGAccountSession;->access$300(Lcom/igg/sdk/account/IGGAccountSession;)Ljava/lang/String;

    move-result-object v6

    .line 260
    invoke-static/range {v0 .. v6}, Lcom/igg/sdk/account/IGGAccountSession;->quickCreate(Lcom/igg/sdk/IGGSDKConstant$IGGLoginType;Ljava/lang/String;Ljava/lang/String;ZLjava/lang/String;Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/account/IGGAccountSession;

    .line 271
    const-string v0, "IGGLoginSession"

    const-string v1, "after  accesskey expirtion time have updated,Session fetched from local storage is valid:"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 272
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-virtual {v0}, Lcom/igg/sdk/account/IGGAccountSession;->dumpToLogCat()V

    .line 273
    iget-object v0, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$listener:Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;

    const/4 v1, 0x0

    const/4 v2, 0x0

    iget-object v3, p0, Lcom/igg/sdk/account/IGGAccountSession$1;->val$session:Lcom/igg/sdk/account/IGGAccountSession;

    invoke-interface {v0, v1, v2, v3}, Lcom/igg/sdk/account/IGGAccountSession$IGGSessionListener;->onSessionExpired(ZZLcom/igg/sdk/account/IGGAccountSession;)V

    goto/16 :goto_0
.end method
