.class Lcom/igg/sdk/incident/IGGIncidentCollector$1;
.super Ljava/lang/Object;
.source "IGGIncidentCollector.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/incident/IGGIncidentCollector;->saveIncident(Lcom/igg/sdk/incident/IGGIncident;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/incident/IGGIncidentCollector;

.field final synthetic val$listener:Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/incident/IGGIncidentCollector;Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/incident/IGGIncidentCollector;

    .prologue
    .line 140
    iput-object p1, p0, Lcom/igg/sdk/incident/IGGIncidentCollector$1;->this$0:Lcom/igg/sdk/incident/IGGIncidentCollector;

    iput-object p2, p0, Lcom/igg/sdk/incident/IGGIncidentCollector$1;->val$listener:Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 7
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    const/4 v6, 0x0

    .line 145
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v3

    if-eqz v3, :cond_0

    .line 146
    sget-object v3, Lcom/igg/sdk/incident/IGGIncidentCollector;->TAG:Ljava/lang/String;

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "saveIncident request failed: "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->w(Ljava/lang/String;Ljava/lang/String;)I

    .line 147
    iget-object v3, p0, Lcom/igg/sdk/incident/IGGIncidentCollector$1;->val$listener:Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;

    const-string v4, "105"

    invoke-interface {v3, v6, v4, p3}, Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;->onFinished(ZLjava/lang/String;Ljava/lang/String;)V

    .line 163
    :goto_0
    return-void

    .line 152
    :cond_0
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 153
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v3, "error_code"

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getJSONObject(Ljava/lang/String;)Lorg/json/JSONObject;

    move-result-object v2

    .line 154
    .local v2, "errorCode":Lorg/json/JSONObject;
    if-eqz v2, :cond_1

    const-string v3, "1"

    invoke-virtual {v2, v3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_1

    .line 155
    iget-object v3, p0, Lcom/igg/sdk/incident/IGGIncidentCollector$1;->val$listener:Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;

    const/4 v4, 0x1

    const-string v5, "0"

    invoke-interface {v3, v4, v5, p3}, Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;->onFinished(ZLjava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 159
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v2    # "errorCode":Lorg/json/JSONObject;
    :catch_0
    move-exception v1

    .line 160
    .local v1, "e":Lorg/json/JSONException;
    invoke-virtual {v1}, Lorg/json/JSONException;->printStackTrace()V

    .line 161
    iget-object v3, p0, Lcom/igg/sdk/incident/IGGIncidentCollector$1;->val$listener:Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;

    const-string v4, "106"

    const-string v5, ""

    invoke-interface {v3, v6, v4, v5}, Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;->onFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 157
    .end local v1    # "e":Lorg/json/JSONException;
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    .restart local v2    # "errorCode":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    iget-object v3, p0, Lcom/igg/sdk/incident/IGGIncidentCollector$1;->val$listener:Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;

    const/4 v4, 0x0

    const-string v5, "106"

    invoke-interface {v3, v4, v5, p3}, Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;->onFinished(ZLjava/lang/String;Ljava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_0
.end method
