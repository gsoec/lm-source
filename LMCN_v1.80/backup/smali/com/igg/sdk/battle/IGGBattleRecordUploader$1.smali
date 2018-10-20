.class Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;
.super Ljava/lang/Object;
.source "IGGBattleRecordUploader.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$GeneralRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/battle/IGGBattleRecordUploader;->uploadFileRequest(Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

.field final synthetic val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

.field final synthetic val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;


# direct methods
.method constructor <init>(Lcom/igg/sdk/battle/IGGBattleRecordUploader;Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    .prologue
    .line 129
    iput-object p1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    iput-object p2, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;

    iput-object p3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V
    .locals 8
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "statusCode"    # Ljava/lang/Integer;
    .param p3, "responseString"    # Ljava/lang/String;

    .prologue
    const/16 v7, 0x66

    const/4 v6, 0x0

    .line 134
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isOccurred()Z

    move-result v3

    if-eqz v3, :cond_2

    .line 135
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v3

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v4}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$100(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v4

    if-ge v3, v4, :cond_1

    .line 136
    const-string v3, "IGGBattleRecordUplader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "try times:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, " network error"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 137
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$008(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    .line 138
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    invoke-static {v3, v4, v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$200(Lcom/igg/sdk/battle/IGGBattleRecordUploader;Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V

    .line 181
    :cond_0
    :goto_0
    return-void

    .line 141
    :cond_1
    const-string v3, "IGGBattleRecordUplader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "try times:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, " network error"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 142
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v3, v6}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$002(Lcom/igg/sdk/battle/IGGBattleRecordUploader;I)I

    .line 143
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;

    const/16 v5, 0x65

    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->getOriginal()Ljava/lang/Exception;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    invoke-interface {v3, v4, v5, v6}, Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;->onUplaoadFailed(Lcom/igg/sdk/battle/IGGBattleRecord;ILjava/lang/String;)V

    goto :goto_0

    .line 149
    :cond_2
    const-string v3, "IGGBattleRecordUplader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "responseString =>"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 150
    if-eqz p3, :cond_4

    const-string v3, ""

    invoke-virtual {p3, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_4

    .line 152
    :try_start_0
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p3}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    .line 153
    .local v0, "JSON":Lorg/json/JSONObject;
    const-string v3, "errcode"

    invoke-virtual {v0, v3}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    .line 154
    .local v2, "errCode":Ljava/lang/String;
    const-string v3, "0"

    invoke-virtual {v2, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-eqz v3, :cond_3

    .line 155
    const-string v3, "IGGBattleRecordUplader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "try times:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, " startupload success"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 156
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v5

    add-int/lit8 v5, v5, 0x1

    invoke-interface {v3, v4, v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;->onUploadFinished(Lcom/igg/sdk/battle/IGGBattleRecord;I)V
    :try_end_0
    .catch Lorg/json/JSONException; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 162
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v2    # "errCode":Ljava/lang/String;
    :catch_0
    move-exception v1

    .line 163
    .local v1, "e":Lorg/json/JSONException;
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v3

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v4}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$100(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v4

    if-ge v3, v4, :cond_0

    .line 164
    const-string v3, "IGGBattleRecordUplader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "try times:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, " server error"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 165
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$008(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    .line 166
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    invoke-static {v3, v4, v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$200(Lcom/igg/sdk/battle/IGGBattleRecordUploader;Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V

    goto/16 :goto_0

    .line 158
    .end local v1    # "e":Lorg/json/JSONException;
    .restart local v0    # "JSON":Lorg/json/JSONObject;
    .restart local v2    # "errCode":Ljava/lang/String;
    :cond_3
    :try_start_1
    const-string v3, "IGGBattleRecordUplader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "try times:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, " server error"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 159
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    const/4 v4, 0x0

    invoke-static {v3, v4}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$002(Lcom/igg/sdk/battle/IGGBattleRecordUploader;I)I

    .line 160
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;

    const/16 v5, 0x66

    invoke-interface {v3, v4, v5, p3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;->onUplaoadFailed(Lcom/igg/sdk/battle/IGGBattleRecord;ILjava/lang/String;)V
    :try_end_1
    .catch Lorg/json/JSONException; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_0

    .line 170
    .end local v0    # "JSON":Lorg/json/JSONObject;
    .end local v2    # "errCode":Ljava/lang/String;
    :cond_4
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v3

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v4}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$100(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v4

    if-ge v3, v4, :cond_5

    .line 171
    const-string v3, "IGGBattleRecordUplader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "try times:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, " server error"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 172
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$008(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    .line 173
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    invoke-static {v3, v4, v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$200(Lcom/igg/sdk/battle/IGGBattleRecordUploader;Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V

    goto/16 :goto_0

    .line 176
    :cond_5
    const-string v3, "IGGBattleRecordUplader"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "try times:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-object v5, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v5}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I

    move-result v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, " server error"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 177
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->this$0:Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    invoke-static {v3, v6}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->access$002(Lcom/igg/sdk/battle/IGGBattleRecordUploader;I)I

    .line 178
    iget-object v3, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$listener:Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    iget-object v4, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;->val$recordFile:Lcom/igg/sdk/battle/IGGBattleRecord;

    invoke-interface {v3, v4, v7, p3}, Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;->onUplaoadFailed(Lcom/igg/sdk/battle/IGGBattleRecord;ILjava/lang/String;)V

    goto/16 :goto_0
.end method
