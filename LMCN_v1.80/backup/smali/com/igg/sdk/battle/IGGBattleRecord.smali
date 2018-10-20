.class public Lcom/igg/sdk/battle/IGGBattleRecord;
.super Ljava/lang/Object;
.source "IGGBattleRecord.java"


# instance fields
.field private baseName:Ljava/lang/String;

.field private localFile:Ljava/io/File;


# direct methods
.method public constructor <init>(Ljava/io/File;)V
    .locals 1
    .param p1, "localFile"    # Ljava/io/File;

    .prologue
    .line 28
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 29
    invoke-virtual {p1}, Ljava/io/File;->getName()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecord;->baseName:Ljava/lang/String;

    .line 30
    iput-object p1, p0, Lcom/igg/sdk/battle/IGGBattleRecord;->localFile:Ljava/io/File;

    .line 31
    return-void
.end method


# virtual methods
.method public getBaseName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 51
    iget-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecord;->baseName:Ljava/lang/String;

    return-object v0
.end method

.method public getLocalFile()Ljava/io/File;
    .locals 1

    .prologue
    .line 60
    iget-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecord;->localFile:Ljava/io/File;

    return-object v0
.end method

.method public uniqueName()Ljava/lang/String;
    .locals 3

    .prologue
    .line 41
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "br_"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/sdk/battle/IGGBattleRecord;->baseName:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 42
    .local v0, "newName":Ljava/lang/String;
    return-object v0
.end method
