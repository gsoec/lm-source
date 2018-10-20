.class final Lcom/igg/util/UUIDUtil$2;
.super Ljava/lang/Object;
.source "UUIDUtil.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/util/UUIDUtil;->getSDUUID(Landroid/content/Context;)Ljava/lang/String;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation


# instance fields
.field final synthetic val$context:Landroid/content/Context;


# direct methods
.method constructor <init>(Landroid/content/Context;)V
    .locals 0

    .prologue
    .line 157
    iput-object p1, p0, Lcom/igg/util/UUIDUtil$2;->val$context:Landroid/content/Context;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 1

    .prologue
    .line 160
    iget-object v0, p0, Lcom/igg/util/UUIDUtil$2;->val$context:Landroid/content/Context;

    invoke-static {v0}, Lcom/igg/util/UUIDUtil;->access$100(Landroid/content/Context;)Ljava/lang/String;

    .line 161
    return-void
.end method
