.class final Lcom/igg/util/UUIDUtil$1;
.super Ljava/lang/Object;
.source "UUIDUtil.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/util/UUIDUtil;->getUUID(Landroid/content/Context;)Ljava/lang/String;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation


# instance fields
.field final synthetic val$context:Landroid/content/Context;

.field final synthetic val$uuidStr:Ljava/lang/String;


# direct methods
.method constructor <init>(Landroid/content/Context;Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 49
    iput-object p1, p0, Lcom/igg/util/UUIDUtil$1;->val$context:Landroid/content/Context;

    iput-object p2, p0, Lcom/igg/util/UUIDUtil$1;->val$uuidStr:Ljava/lang/String;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 2

    .prologue
    .line 52
    iget-object v0, p0, Lcom/igg/util/UUIDUtil$1;->val$context:Landroid/content/Context;

    iget-object v1, p0, Lcom/igg/util/UUIDUtil$1;->val$uuidStr:Ljava/lang/String;

    invoke-static {v0, v1}, Lcom/igg/util/UUIDUtil;->access$000(Landroid/content/Context;Ljava/lang/String;)Ljava/lang/String;

    .line 53
    return-void
.end method
