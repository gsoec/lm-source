.class Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;
.super Ljava/lang/Object;
.source "IGGAdwordsEventReporter.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->report(Ljava/util/HashMap;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

.field final synthetic val$listener:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;


# direct methods
.method constructor <init>(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    .prologue
    .line 98
    iput-object p1, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;->this$0:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    iput-object p2, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;->val$listener:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 5
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    .line 102
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v2

    if-eqz v2, :cond_0

    .line 103
    const-string v2, "IGGAdwordsEventReporter"

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v3

    invoke-static {v3}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 104
    iget-object v2, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;->val$listener:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;

    iget-object v3, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;->this$0:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getErrorCode()I

    move-result v4

    invoke-static {v3, v4}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->access$000(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;I)Lcom/igg/sdk/error/IGGException;

    move-result-object v3

    invoke-interface {v2, v3}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;->onFinished(Lcom/igg/sdk/error/IGGException;)V

    .line 124
    :goto_0
    return-void

    .line 109
    :cond_0
    :try_start_0
    const-string v2, "IGGAdwordsEventReporter"

    invoke-static {v2, p3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 110
    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 111
    .local v1, "json":Lorg/json/JSONObject;
    const-string v2, "IGGAdwordsEventReporter"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "getInt(\"error_no\")"

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v4, "error_no"

    invoke-virtual {v1, v4}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 112
    const-string v2, "error_no"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v2

    if-nez v2, :cond_1

    .line 113
    iget-object v2, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;->val$listener:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGException;->noneException()Lcom/igg/sdk/error/IGGException;

    move-result-object v3

    invoke-interface {v2, v3}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;->onFinished(Lcom/igg/sdk/error/IGGException;)V

    .line 114
    const-string v2, "IGGAdwordsEventReporter"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "isNone = "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-static {}, Lcom/igg/sdk/error/IGGException;->noneException()Lcom/igg/sdk/error/IGGException;

    move-result-object v4

    invoke-virtual {v4}, Lcom/igg/sdk/error/IGGException;->isNone()Z

    move-result v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 118
    .end local v1    # "json":Lorg/json/JSONObject;
    :catch_0
    move-exception v0

    .line 119
    .local v0, "e":Lorg/json/JSONException;
    const-string v2, "IGGAdwordsEventReporter"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "JSONException  = "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v0}, Lorg/json/JSONException;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v2, v3}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 120
    invoke-virtual {v0}, Lorg/json/JSONException;->printStackTrace()V

    .line 121
    iget-object v2, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;->val$listener:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;

    const-string v3, "2091011003"

    const-string v4, "20"

    invoke-static {v3, v4}, Lcom/igg/sdk/error/IGGException;->exception(Ljava/lang/String;Ljava/lang/String;)Lcom/igg/sdk/error/IGGException;

    move-result-object v3

    invoke-interface {v2, v3}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;->onFinished(Lcom/igg/sdk/error/IGGException;)V

    goto/16 :goto_0

    .line 116
    .end local v0    # "e":Lorg/json/JSONException;
    .restart local v1    # "json":Lorg/json/JSONObject;
    :cond_1
    :try_start_1
    iget-object v2, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;->val$listener:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;

    iget-object v3, p0, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$1;->this$0:Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;

    const-string v4, "error_no"

    invoke-virtual {v1, v4}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v4

    invoke-static {v3, v4}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;->access$000(Lcom/igg/sdk/marketing/IGGAdwordsEventReporter;I)Lcom/igg/sdk/error/IGGException;

    move-result-object v3

    invoke-interface {v2, v3}, Lcom/igg/sdk/marketing/IGGAdwordsEventReporter$IGGAdwordsEventReportListener;->onFinished(Lcom/igg/sdk/error/IGGException;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0
.end method
