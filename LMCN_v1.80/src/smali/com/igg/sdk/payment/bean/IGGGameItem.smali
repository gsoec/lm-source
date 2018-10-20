.class public Lcom/igg/sdk/payment/bean/IGGGameItem;
.super Ljava/lang/Object;
.source "IGGGameItem.java"

# interfaces
.implements Ljava/io/Serializable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/payment/bean/IGGGameItem$Flag;,
        Lcom/igg/sdk/payment/bean/IGGGameItem$Type;
    }
.end annotation


# instance fields
.field private creditRate:D

.field private flag:I

.field private freePoint:Ljava/lang/Integer;

.field private id:Ljava/lang/Integer;

.field private pcc_third_party_id:Ljava/lang/String;

.field private point:Ljava/lang/Integer;

.field private purchase:Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

.field private selected:Z

.field private title:Ljava/lang/String;

.field private type:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static createFromJSON(Lorg/json/JSONObject;)Lcom/igg/sdk/payment/bean/IGGGameItem;
    .locals 4
    .param p0, "JSON"    # Lorg/json/JSONObject;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Lorg/json/JSONException;
        }
    .end annotation

    .prologue
    .line 110
    new-instance v0, Lcom/igg/sdk/payment/bean/IGGGameItem;

    invoke-direct {v0}, Lcom/igg/sdk/payment/bean/IGGGameItem;-><init>()V

    .line 112
    .local v0, "item":Lcom/igg/sdk/payment/bean/IGGGameItem;
    const-string v1, "pc_id"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->id:Ljava/lang/Integer;

    .line 113
    const-string v1, "pc_name"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->title:Ljava/lang/String;

    .line 114
    const-string v1, "pc_point"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->point:Ljava/lang/Integer;

    .line 115
    const-string v1, "pc_free_point"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v1

    invoke-static {v1}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->freePoint:Ljava/lang/Integer;

    .line 116
    const-string v1, "pc_type"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v1

    iput v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->type:I

    .line 117
    const-string v1, "pc_flag"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v1

    iput v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->flag:I

    .line 119
    const-string v1, "pc_selected"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    const-string v2, "1"

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    iput-boolean v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->selected:Z

    .line 120
    const-string v1, "pc_credit_rate"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getInt(Ljava/lang/String;)I

    move-result v1

    int-to-double v2, v1

    iput-wide v2, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->creditRate:D

    .line 121
    const-string v1, "pcc_third_party_id"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->isNull(Ljava/lang/String;)Z

    move-result v1

    if-nez v1, :cond_0

    .line 122
    const-string v1, "pcc_third_party_id"

    invoke-virtual {p0, v1}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->pcc_third_party_id:Ljava/lang/String;

    .line 125
    :cond_0
    invoke-static {p0}, Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;->createFromJSON(Lorg/json/JSONObject;)Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    move-result-object v1

    iput-object v1, v0, Lcom/igg/sdk/payment/bean/IGGGameItem;->purchase:Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;

    .line 127
    return-object v0
.end method


# virtual methods
.method public declared-synchronized getCreditRate()D
    .locals 2

    .prologue
    .line 197
    monitor-enter p0

    :try_start_0
    iget-wide v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->creditRate:D
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-wide v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getFlag()I
    .locals 1

    .prologue
    .line 181
    monitor-enter p0

    :try_start_0
    iget v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->flag:I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getFreePoint()Ljava/lang/Integer;
    .locals 1

    .prologue
    .line 159
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->freePoint:Ljava/lang/Integer;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getId()Ljava/lang/Integer;
    .locals 1

    .prologue
    .line 134
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->id:Ljava/lang/Integer;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getPcc_third_party_id()Ljava/lang/String;
    .locals 1

    .prologue
    .line 208
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->pcc_third_party_id:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getPoint()Ljava/lang/Integer;
    .locals 1

    .prologue
    .line 150
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->point:Ljava/lang/Integer;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getPurchase()Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;
    .locals 1

    .prologue
    .line 204
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->purchase:Lcom/igg/sdk/payment/bean/IGGGameItemPurchase;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getTitle()Ljava/lang/String;
    .locals 1

    .prologue
    .line 141
    monitor-enter p0

    :try_start_0
    iget-object v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->title:Ljava/lang/String;
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return-object v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized getType()I
    .locals 1

    .prologue
    .line 170
    monitor-enter p0

    :try_start_0
    iget v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->type:I
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method

.method public declared-synchronized isSelected()Z
    .locals 1

    .prologue
    .line 188
    monitor-enter p0

    :try_start_0
    iget-boolean v0, p0, Lcom/igg/sdk/payment/bean/IGGGameItem;->selected:Z
    :try_end_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    monitor-exit p0

    return v0

    :catchall_0
    move-exception v0

    monitor-exit p0

    throw v0
.end method
