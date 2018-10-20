.class Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$1;
.super Ljava/lang/Object;
.source "IGGAppConfigHelper.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->LoadGameConfig()V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    .prologue
    .line 29
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$1;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/bean/IGGAppConfig;)V
    .locals 3
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "appconfig"    # Lcom/igg/sdk/bean/IGGAppConfig;

    .prologue
    .line 33
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 35
    if-eqz p2, :cond_0

    .line 37
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$1;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$1;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->GameMaintanceCallBackSuccessful:Ljava/lang/String;

    invoke-virtual {p2}, Lcom/igg/sdk/bean/IGGAppConfig;->getRawString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 38
    const-string v0, "GameMaintanceCallBackSuccessful"

    invoke-virtual {p2}, Lcom/igg/sdk/bean/IGGAppConfig;->getRawString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 43
    :goto_0
    return-void

    .line 42
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$1;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    iget-object v1, p0, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper$1;->this$0:Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;

    iget-object v1, v1, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->GameMaintanceCallBackFailed:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v0, v1, v2}, Lcom/igg/iggsdkbusiness/IGGAppConfigHelper;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0
.end method
