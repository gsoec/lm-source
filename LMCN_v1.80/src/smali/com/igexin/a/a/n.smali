.class public Lcom/igexin/a/a/n;
.super Lcom/igexin/a/a/g;


# direct methods
.method public constructor <init>(Lcom/igexin/a/a/j;Lcom/igexin/a/a/e;I)V
    .locals 6

    invoke-direct {p0}, Lcom/igexin/a/a/g;-><init>()V

    const/16 v0, 0x8

    invoke-static {v0}, Ljava/nio/ByteBuffer;->allocate(I)Ljava/nio/ByteBuffer;

    move-result-object v1

    iget-boolean v0, p2, Lcom/igexin/a/a/e;->a:Z

    if-eqz v0, :cond_0

    sget-object v0, Ljava/nio/ByteOrder;->BIG_ENDIAN:Ljava/nio/ByteOrder;

    :goto_0
    invoke-virtual {v1, v0}, Ljava/nio/ByteBuffer;->order(Ljava/nio/ByteOrder;)Ljava/nio/ByteBuffer;

    iget-wide v2, p2, Lcom/igexin/a/a/e;->d:J

    iget v0, p2, Lcom/igexin/a/a/e;->g:I

    mul-int/2addr v0, p3

    int-to-long v4, v0

    add-long/2addr v2, v4

    const-wide/16 v4, 0x2c

    add-long/2addr v2, v4

    invoke-virtual {p1, v1, v2, v3}, Lcom/igexin/a/a/j;->c(Ljava/nio/ByteBuffer;J)J

    move-result-wide v0

    iput-wide v0, p0, Lcom/igexin/a/a/n;->a:J

    return-void

    :cond_0
    sget-object v0, Ljava/nio/ByteOrder;->LITTLE_ENDIAN:Ljava/nio/ByteOrder;

    goto :goto_0
.end method
